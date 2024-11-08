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

namespace Infrastructure.Repository.ContasPagar
{
    //public class RepositoryPaciente : RepositoryGeneric<RepositoryPaciente>, IPacienteRepository //nome da interface//
    public class RepositoryContasPagar : IContasPagarRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryContasPagar()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.ContasPagar Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasPagar>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.ContasPagar Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasPagar>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.ContasPagar Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasPagar>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.ContasPagar>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasPagar>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.ContasPagar> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasPagar>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }

}
