using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Infrasrtructure;
using PortfolioManager.DTO;
using PortfolioManager.Domain;





// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComController : ControllerBase
    {
        private readonly ComRepository _comRepository;
        // private readonly StRepository _stRepository;
        private readonly Context _context;

        public ComController(Context context)
        {
            _comRepository = new ComRepository(context);
        }

        // GET: api/<ComController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComDTO>>> GetCompetitions()
        {
            var competitions = await _comRepository.GetAllAsync();
            List<ComDTO> comDTOs = new List<ComDTO>();
            foreach (var competition in competitions)
            {
                comDTOs.Add(ToComDTO(competition));
            }
            return comDTOs;

        }


        // GET api/<ComController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComDTO>> GetCompetition(Guid id)
        {
            var competition = await _comRepository.GetByIdAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            return ToComDTO(competition);
        }

        // POST api/<ComController>
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {          
            await _comRepository.AddAsync(competition);
            return Ok();
        }

        // PUT api/<ComController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(Guid id, Competition competition)
        {
            var com = await _comRepository.GetByIdAsync(id);
            if (id != competition.Id || com == null)
            {
                return BadRequest();
            }
            await _comRepository.UpdateAsync(competition);
            return NoContent();

        }

        // DELETE api/<ComController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            var competition = await _comRepository.GetByIdAsync(id);

            if (competition == null)
            {
                return NotFound();
            }
            await _comRepository.DeleteAsync(id);
            return NoContent();
        }

        private ComDTO ToComDTO(Competition competition)
        {
            ComDTO comDTO = new ComDTO
            {
                Id = competition.Id,
                Type = competition.Type,
                Certificate = competition.Certificate,
                Date = competition.Date,
                Name = competition.Name,
                URL = competition.URL,
                Organizer= competition.Organizer,
                View= competition.View,
                Result=competition.Result,
                Stages = ToStDTO(competition.Stages)
            };
            return comDTO;
        }
        private List<StDTO> ToStDTO(List<Stage> stages)
        {
            List<StDTO> stDTOs = new List<StDTO>();
            foreach (var stage in stages)
            {
                StDTO stDTO = new StDTO
                {
                    Id = stage.Id,
                    Number = stage.Number,
                    Result = stage.Result,
                    Fund = stage.Fund,
                    Deadline = stage.Deadline,
                    Participants = ToPartDTO(stage.Participants),
                    CompetitionId = stage.CompetitionId
                };
                stDTOs.Add(stDTO);
            }
            return stDTOs;
        }
        private List<PartDTO> ToPartDTO(List<Participant> participants)
        {
            List<PartDTO> ptDTOs = new List<PartDTO>();
            foreach (var pt in participants)
            {
                PartDTO ptDTO = new PartDTO
                {
                    Id = pt.Id,
                    PersonId = pt.PersonId,
                    Name = pt.Name,
                    Surname = pt.Surname,
                    Middlename = pt.Middlename,
                    Role = pt.Role,
                    StageId = pt.StageId
                };
                ptDTOs.Add(ptDTO);
            }
            return ptDTOs;
        }
    }
}
