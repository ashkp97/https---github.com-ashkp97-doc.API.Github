using System.Threading.Tasks;
using doctor.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class DoctorController : ControllerBase
{
    private readonly IDoctorService _docService;

    public DoctorController(IDoctorService docService)
    {
        _docService = docService;
    }

    [HttpGet]
    [Route("api/[controller]")]
    [Authorize]
    public async Task<ActionResult<List<GetDoctorResponseDto>>> GetAllDoctors()
    {
        try
        {
            var doctors = await _docService.GetDoctors();
            return Ok(doctors);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("api/[controller]/{id}")]
    [Authorize]
    public async Task<ActionResult<GetDoctorResponseDto>> GetDoctorById(int id)
    {
        try
        {
            var doctor = await _docService.GetDoctorById(id);
            return Ok(doctor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AddDoctorResponseDto>> CreateDoctor([FromBody] AddDoctorRequestDto doctor)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _docService.AddNewDoctor(doctor);
                return Created("", result);
            }
            else
            {
                return BadRequest("Invalid doctor object");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("api/[controller]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateDoctorResponseDto>> UpdateDoctor(int id, [FromBody] UpdateDoctorRequestDto doctor)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _docService.UpdateDoctor(id, doctor);
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid doctor object");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("api/[controller]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<GetDoctorResponseDto>> DeleteDoctor(int id)
    {
        try
        {
            var result = await _docService.DeleteDoctor(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 
}