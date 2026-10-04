using System;
using System.Collections.Generic;
using System.Threading;
using XpressShare.Core;
using XpressShare.Storage;

namespace XpressShare.Services
{
    public class TransferHistoryService
    {
        private readonly TransferHistoryRepository _repository;

        public TransferHistoryService()
        {
            _repository = new TransferHistoryRepository();
        }

        public void RecordTransfer(string remoteDeviceId, string remoteDeviceName, string filePath, long fileSize, bool success, bool isUpload)
        {
            try
            {
                _repository.RecordTransfer(remoteDeviceId, remoteDeviceName, filePath, fileSize, success, isUpload);
                AppLogger.Log("Transfer recorded: " + (isUpload ? "uploaded to " : "downloaded from ") + remoteDeviceName + " (" + (success ? "Success" : "Failed") + ")");
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferHistoryService.RecordTransfer error: " + ex.Message);
            }
        }

        public void RecordTransferAsync(string remoteDeviceId, string remoteDeviceName, string filePath, long fileSize, bool success, bool isUpload)
        {
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                RecordTransfer(remoteDeviceId, remoteDeviceName, filePath, fileSize, success, isUpload);
            });
        }

        public List<TransferHistoryRepository.TransferHistoryEntry> GetHistory()
        {
            try
            {
                return _repository.GetHistory();
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferHistoryService.GetHistory error: " + ex.Message);
                return new List<TransferHistoryRepository.TransferHistoryEntry>();
            }
        }

        public List<TransferHistoryRepository.TransferHistoryEntry> GetHistoryAfter(DateTime date)
        {
            try
            {
                return _repository.GetHistoryAfter(date);
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferHistoryService.GetHistoryAfter error: " + ex.Message);
                return new List<TransferHistoryRepository.TransferHistoryEntry>();
            }
        }

        public void ClearHistory()
        {
            try
            {
                _repository.ClearHistory();
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferHistoryService.ClearHistory error: " + ex.Message);
            }
        }
    }
}
