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
{/*
    public class AttestationLogic : IAttestationLogic
    {
        private readonly ILogger _logger;
        private readonly IAttestationStorage _attestationStorage;
        public AttestationLogic(ILogger<AttestationLogic> logger, IAttestationStorage
       attestationStorage)
        {
            _logger = logger;
            _attestationStorage = attestationStorage;
        }
        public List<AttestationViewModel>? ReadList(AttestationSearchModel? model)
        {
            _logger.LogInformation("ReadList. FormOfEvaluation: {FormOfEvaluation}.Id:{Id} ",
                model?.FormOfEvaluation, model?.Id);
            var list = model == null ? _attestationStorage.GetFullList() :
                    _attestationStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public AttestationViewModel? ReadElement(AttestationSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. FormOfEvaluation:{FormOfEvaluation}.Id:{Id}",
                model.FormOfEvaluation, model.Id);
            var element = _attestationStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(AttestationBindingModel model)
        {
            CheckModel(model);

            model.Score = AttestationScore.Неявка;

            if (_attestationStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            return true;
        }
        public bool StatusUpdate(AttestationBindingModel model, AttestationScore newScore)
        {
            CheckModel(model);
            if (model.Score + 1 != newScore)
            {
                _logger.LogWarning("Status update to " + newScore.ToString() + " operation failed. Order status incorrect.");
                return false;
            }

            model.Score = newScore;

            if (model.Score == AttestationScore.Выдан)
                model.DateImplement = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            if (_attestationStorage.Update(model) == null)
            {
                model.Score--;
                _logger.LogWarning("Update operation failed");
                return false;
            }

            return true;
        }
        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выполняется);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Готов);
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выдан);
        }

        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.WorkId < 0)
            {
                throw new ArgumentNullException("Некорректный идентификатор изделия", nameof(model.WorkId));
            }

            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество изделий в заказе должно быть больше 0", nameof(model.Count));
            }

            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Сумма заказа должна быть больше 0", nameof(model.Sum));
            }
            _logger.LogInformation("Order. OrderId:{Id}.Sum:{ Sum}. WorkId: { WorkId}", model.Id, model.Sum, model.WorkId);
        }
    }*/
}
