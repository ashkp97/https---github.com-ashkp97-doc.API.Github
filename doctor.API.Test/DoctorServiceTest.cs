using AutoMapper;
using doctor.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace doctor.API.Test;

public class DoctorServiceTest
{
    ClinicContext _context;
    IRepository<int, Doctor> docRepo;
    IRepository<int, Department> deptRepo;
    IRepository<int, User> userRepo;
    IMapper mapper;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ClinicContext>()
                        .UseInMemoryDatabase("TestDb")
                        .Options;
        _context = new ClinicContext(options);
        docRepo = new DoctorRepositoryDBContext(_context);
        deptRepo = new DepartmentRepository(_context);
        userRepo = new UserRepository(_context);
    }

    [Test]
    [TestCase(101, "Test4", 1)]
    [TestCase(102, "Test5", 2)]
    [TestCase(103, "Test6", 3)]
    public async Task AddEmployeeSuccessTest(int departmentId, string name, int did)
    {
        //Arrange    
        _context.Add(new Department { DepartmentNumber = departmentId, Name = "Test" });
        await _context.SaveChangesAsync();
        var reqObj = new AddDoctorRequestDto { Name = name, Phone = "1234567890", DepartmentId = departmentId };
        var respObj = new AddDoctorResponseDto { Id = did, Name = name, Phone = "1234567890", DepartmnetName = "Test" };
        var doc = new Doctor { Name = name, PhoneNumber = "1234567890", DepartmentId = departmentId };
        Mock<IMapper> mapper = new Mock<IMapper>();
        mapper.Setup(mapper => mapper.Map<Doctor>(It.IsAny<AddDoctorRequestDto>())).Returns(doc);
        mapper.Setup(mapper => mapper.Map<AddDoctorResponseDto>(It.IsAny<Doctor>())).Returns(respObj);
        Mock<ILogger<Doctor>> logger = new Mock<ILogger<Doctor>>();
        
        IDoctorService docService = new DoctorService(docRepo, deptRepo, mapper.Object, userRepo, logger.Object);
        //Action        
        var result = await docService.AddNewDoctor(reqObj);
        //Assert
        Assert.That(result.Id, Is.EqualTo(did));
    }

    [Test]
    [TestCase(104, "Test4", 4)]
    public async Task AddEmployeeExceptionTest(int departmentId, string name, int did)
    {
        //Arrange    
        _context.Add(new Department { DepartmentNumber = departmentId, Name = "Test" });
        await _context.SaveChangesAsync();
        var reqObj = new AddDoctorRequestDto { Name = name, Phone = "1234567890", DepartmentId = departmentId };
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<ILogger<Doctor>> logger = new Mock<ILogger<Doctor>>();

        IDoctorService docService = new DoctorService(docRepo, deptRepo, mapper.Object, userRepo, logger.Object);
        //Assert
        Assert.ThrowsAsync<NullReferenceException>(async () => await docService.AddNewDoctor(reqObj));
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
}