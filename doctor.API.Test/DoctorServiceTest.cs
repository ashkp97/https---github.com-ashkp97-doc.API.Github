using AutoMapper;
using doctor.API.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        _context.Add(new Department { DepartmentNumber = departmentId, Name = "Test" });
        await _context.SaveChangesAsync();
        //Arrange    
        var reqObj = new AddDoctorRequestDto { Name = name, Phone = "1234567890", DepartmentId = departmentId };
        var respObj = new AddDoctorResponseDto { Id = did, Name = name, Phone = "1234567890", DepartmnetName = "Test" };
        var doc = new Doctor { Name = name, PhoneNumber = "1234567890", DepartmentId = departmentId };
        Mock<IMapper> mapper = new Mock<IMapper>();
        mapper.Setup(mapper => mapper.Map<Doctor>(It.IsAny<AddDoctorRequestDto>())).Returns(doc);
        mapper.Setup(mapper => mapper.Map<AddDoctorResponseDto>(It.IsAny<Doctor>())).Returns(respObj);
        IDoctorService docService = new DoctorService(docRepo, deptRepo, mapper.Object, userRepo);
        //Action        
        var result = await docService.AddNewDoctor(reqObj);
        //Assert
        Assert.That(result.Id, Is.EqualTo(did));
    }

    // [Test]
    // [TestCase(110, null)]
    // public async Task AddEmployeeFailureTest(int departmentId, string? name)
    // {
    //      //Arrange        
    //     IRepository<int, Doctor> docRepo = new DoctorRepositoryDBContext(_context);
    //     var doc = new Doctor { Name = name, PhoneNumber = "1234567890", DepartmentId = departmentId };
    //     //Action        
    //     //var result = await docRepo.Add(doc);
    //     var ex = Assert.ThrowsAsync<DbUpdateException>(async () => await docRepo.Add(doc));
    //     //Assert
    //     Assert.That(ex.Message, Does.Contain("Required properties '{'Name'}' are missing for the instance of entity type 'Doctor'."));
    // }
    // [Test]
    // public async Task AddEmployeeExceptionTest()
    // {
    //     //Arrange

    //     //Action

    //     //Assert

    // }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
}