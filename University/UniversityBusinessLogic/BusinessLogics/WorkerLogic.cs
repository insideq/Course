using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDataModels.Enums;

namespace UniversityBusinessLogic.BusinessLogics
{
    public class WorkerLogic : IWorkerLogic
    {
        private readonly ILogger _logger;
        private readonly IWorkerStorage _workerStorage;
        public WorkerLogic(ILogger<WorkerLogic> logger, IWorkerStorage
        workerStorage)
        {
            _logger = logger;
            _workerStorage = workerStorage;
        }
        public List<WorkerViewModel>? ReadList(WorkerSearchModel? model)
        {
            _logger.LogInformation("ReadList. FirstName: {FirstName}.LastName: {LastName}. PhoneNumber: {PhoneNumber}" +
                "Email: {Email}.Id:{Id} ",
                model?.FirstName, model?.LastName, model?.PhoneNumber, model?.Email, model?.Id);
            var list = model == null ? _workerStorage.GetFullList() :
                _workerStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public WorkerViewModel? ReadElement(WorkerSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadList. FirstName: {FirstName}.LastName: {LastName}. PhoneNumber: {PhoneNumber}" +
                "Email: {Email}.Id:{Id} ",
                model?.FirstName, model?.LastName, model?.PhoneNumber, model?.Email, model?.Id);
            var element = _workerStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(WorkerBindingModel model)
        {
            CheckModel(model);
            if (_workerStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(WorkerBindingModel model)
        {
            CheckModel(model);
            if (_workerStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(WorkerBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_workerStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(WorkerBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentNullException("Нет имени пользователя",
               nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentNullException("Нет фамилии пользователя",
               nameof(model.LastName));
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                throw new ArgumentNullException("Должен быть номер телефона", nameof(model.PhoneNumber));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentNullException("Не указана почта",
               nameof(model.Email));
            }
            _logger.LogInformation("Worker. FirstName: {FirstName}.LastName: {LastName}. PhoneNumber: " +
                "{PhoneNumber}.Email: {Email}.Id:{Id}",
                model.FirstName, model.LastName, model.PhoneNumber, model.Email, model.Id);
            var element = _workerStorage.GetElement(new WorkerSearchModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Данный пользователь уже существует");
            }
        }
    }
}
