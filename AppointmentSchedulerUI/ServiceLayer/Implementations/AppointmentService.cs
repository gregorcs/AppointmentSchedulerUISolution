using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using RestSharp;

namespace AppointmentSchedulerUI.Repositories.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        public Task Delete(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> Save(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
