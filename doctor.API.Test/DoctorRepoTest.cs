using AutoMapper;
using doctor.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace doctor.API.Test;

public class DoctorRepoTest
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
    [TestCase(101, "Test1", 1)]
    [TestCase(102, "Test2", 2)]
    [TestCase(103, "Test3", 3)]
    public async Task AddEmployeeSuccessTest(int departmentId, string name, int did)
    {
        //Arrange     
        var doc = new Doctor { Name = name, PhoneNumber = "1234567890", DepartmentId = departmentId };
        //Action        
        var result = await docRepo.Add(doc);
        //Assert
        Assert.That(result.Id, Is.EqualTo(did));
    }

    // [Test]
    // [TestCase(104, null, 4)]
    // public async Task AddEmployeeExceptionTest(int departmentId, string? name, int did)
    // {
    //     //Arrange            
    //     var doc = new Doctor { Name = name, PhoneNumber = "1234567890", DepartmentId = departmentId };
    //     await docRepo.Add(doc);
    //     //Assert
    //     Assert.ThrowsAsync<DbUpdateException>(async () => await docRepo.Add(doc));
    // }


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