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

namespace Infrastructure.Repository.Clinica
{
    //public class RepositoryPaciente : RepositoryGeneric<RepositoryPaciente>, IPacienteRepository //nome da interface//
    public class RepositoryClinica : IClinicaRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryClinica()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.Clinica Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Clinica>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.Clinica Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Clinica>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.Clinica Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Clinica>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.Clinica>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Clinica>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.Clinica> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Clinica>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }

}
