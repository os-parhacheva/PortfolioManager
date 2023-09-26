using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace PortfolioManager.Infrasrtructure
{
    public class ComRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ComRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Competition>> GetAllAsync()
        {
            return await _context.Competitions.OrderBy(p => p.Name).Include(p=> p.Stages).ThenInclude(pa=>pa.Participants).ToListAsync();
        }
        public async Task<Competition> GetByIdAsync( Guid id)
        {
            return await _context.Competitions.Include(p => p.Stages).ThenInclude(pa => pa.Participants).SingleOrDefaultAsync(i => i.Id == id);
        }
        public async Task AddAsync(Competition competition)
        {  
            _context.Competitions.Add(competition);            
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Competition competition)
        {
            var existCom = await _context.Competitions.Include(p => p.Stages).SingleOrDefaultAsync(i => i.Id == competition.Id);
            _context.Entry(existCom).CurrentValues.SetValues(competition);

            foreach (var st in competition.Stages)
            {
                var existingSt = existCom.Stages.FirstOrDefault(s => s.Id == st.Id);

                if (existingSt == null)
                {
                    existCom.Stages.Add(st);
                    _context.Entry(existCom).Reload();
                }
                else
                {
                    //st.Id = existingSt.Id;
                    _context.Entry(existingSt).CurrentValues.SetValues(st);
                    foreach (var part in st.Participants)
                    {
                        var existingPart = existingSt.Participants.FirstOrDefault(s => s.Id == part.Id);

                        if (existingPart == null)
                        {
                            existingSt.Participants.Add(part);
                            _context.Entry(existingSt).Reload();
                        }
                        else
                        {
                            _context.Entry(existingPart).CurrentValues.SetValues(part);
                        }

                    }
                    foreach (var part in existingSt.Participants)
                    {
                        if (!st.Participants.Any(p => p.Id == part.Id))
                        {
                            _context.Remove(part);
                        }
                    }

                }
            }

            foreach (var st in existCom.Stages)
            {
                if (!competition.Stages.Any(s => s.Id == st.Id))
                {
                    _context.Remove(st);
                }
            }            
            
            await _context.SaveChangesAsync(); 

        }

        public async Task DeleteAsync(Guid id)
        {
            Competition competition = await _context.Competitions.FindAsync(id);
            _context.Remove(competition);           
            await _context.SaveChangesAsync();
        }

               

    }
}
