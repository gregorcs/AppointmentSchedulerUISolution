﻿using RestSharp;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface ICrudService<T, ID>
    {
        public Task<RestResponse> Save(T entity);
        public Task<int> SaveAll(IEnumerable<T> entities);
        public Task<T> FindById(ID id);
        public Task<bool> ExistsById(ID id);
        public Task<IEnumerable<T>> FindAll();
        public Task<IEnumerable<T>> FindAllById(IEnumerable<ID> Ids);
        public Task DeleteById(ID id);
        public Task Delete(T entity);
        public Task DeleteAll(IEnumerable<T> entities);
    }
}
