using Domain.Interface;
using Domain.Entities;
using Infrastructure.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repository.ContasReceber
{
    //public class RepositoryPaciente : RepositoryGeneric<RepositoryPaciente>, IPacienteRepository //nome da interface//
    public class RepositoryContasReceber : IContasReceberRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryContasReceber()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.ContasReceber Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasReceber>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.ContasReceber Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasReceber>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.ContasReceber Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasReceber>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.ContasReceber>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasReceber>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.ContasReceber> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasReceber>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }

}
