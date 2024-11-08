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

namespace Infrastructure.Repository.Paciente
{
    //public class RepositoryPaciente : RepositoryGeneric<RepositoryPaciente>, IPacienteRepository //nome da interface//
    public class RepositoryPaciente : IPacienteRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryPaciente()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.Paciente Objeto)
        {
            
           // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                 banco.Set<Domain.Entities.Paciente>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.Paciente Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Paciente>().Update(Objeto);
                 await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.Paciente Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Paciente>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task <List<Domain.Entities.Paciente>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Paciente>().AsNoTracking().ToListAsync(); 
            }
        }

        public async Task<Domain.Entities.Paciente> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Paciente>().FindAsync(Id);
            }
        }



            public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }

}
