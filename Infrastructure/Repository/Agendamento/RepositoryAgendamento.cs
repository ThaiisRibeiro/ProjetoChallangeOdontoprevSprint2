using Domain.Interface;
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

namespace Infrastructure.Repository.Agendamento
{
    //public class RepositoryPaciente : RepositoryGeneric<RepositoryPaciente>, IPacienteRepository //nome da interface//
    public class RepositoryAgendamento : IAgendamentoRepository, IDisposable //nome da interface//
    {

        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryAgendamento()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.Agendamento Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Agendamento>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Agendamento>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Agendamento>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.Agendamento>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Agendamento>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.Agendamento> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Agendamento>().FindAsync(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }

}
