using System;
using Microsoft.Extensions.Logging;

namespace AppEnvironment
{
    public class Result
    {
        public Result()
        {

        }

        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public MessageType? MessageType { get; set; }

        public Result(Exception e) //for services 
        {
            this.IsSuccess = false;
            this.Code = 500;
            this.Exception = e;
            this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
        }

        public Result(MessageType type) //for services 
        {
            switch (type)
            {
                case AppEnvironment.MessageType.Unauthorized:
                    this.IsSuccess = false;
                    this.Code = 401;
                    this.MessageType = AppEnvironment.MessageType.Unauthorized;
                    break;
                case AppEnvironment.MessageType.OperationFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.OperationFailed;
                    break;
                case AppEnvironment.MessageType.InsertFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.InsertFailed;
                    break;
                case AppEnvironment.MessageType.UpdateFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.UpdateFailed;
                    break;
                case AppEnvironment.MessageType.DeleteFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.DeleteFailed;
                    break;
                case AppEnvironment.MessageType.RecordNotFound:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.RecordNotFound;
                    break;
                case AppEnvironment.MessageType.PhoneNumberExists:
                    this.IsSuccess = false;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.PhoneNumberExists;
                    break;
                case AppEnvironment.MessageType.EmailExits:
                    this.IsSuccess = false;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.EmailExits;
                    break;
                case AppEnvironment.MessageType.RecordAlreadyExists:
                    this.IsSuccess = false;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.RecordAlreadyExists;
                    break;
                case AppEnvironment.MessageType.ExceptionOccurred:
                    this.IsSuccess = false;
                    this.Code = 500;
                    this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
                    break;
                case AppEnvironment.MessageType.OperationSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.OperationSuccess;
                    break;
                case AppEnvironment.MessageType.InsertSuccess:
                    this.IsSuccess = true;
                    this.Code = 200; //201 de koyulabilir
                    this.MessageType = AppEnvironment.MessageType.InsertSuccess;
                    break;
                case AppEnvironment.MessageType.UpdateSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.UpdateSuccess;
                    break;
                case AppEnvironment.MessageType.DeleteSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.DeleteSuccess;
                    break;

                default:
                    this.IsSuccess = false;
                    this.Code = 500;
                    this.Exception = new ArgumentOutOfRangeException();
                    this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
                    break;
            }
        }
    }

    public class Result<T> : Result
    {
        public Result(T data) //messagetype da verilebilir. operation complaeted tarzi
        {
            this.IsSuccess = true;
            this.Code = 200;
            this.Data = data;
        }

        public Result(Exception e) //for services 
        {
            this.IsSuccess = false;
            this.Code = 500;
            this.Exception = e;
            this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
        }

        public Result(Exception e, ILogger logger, string userId) //for controller services 
        {
            this.IsSuccess = false;
            this.Code = 500;
            this.Exception = e;
            this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
            logger.LogError(e, Message);
        }

        public Result(MessageType type) //for services 
        {
            switch (type)
            {
                case AppEnvironment.MessageType.Unauthorized:
                    this.IsSuccess = false;
                    this.Code = 401;
                    this.MessageType = AppEnvironment.MessageType.Unauthorized;
                    break;
                case AppEnvironment.MessageType.OperationFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.OperationFailed;
                    break;
                case AppEnvironment.MessageType.InsertFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.InsertFailed;
                    break;
                case AppEnvironment.MessageType.UpdateFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.UpdateFailed;
                    break;
                case AppEnvironment.MessageType.DeleteFailed:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.DeleteFailed;
                    break;
                case AppEnvironment.MessageType.RecordNotFound:
                    this.IsSuccess = false;
                    this.Code = 404;
                    this.MessageType = AppEnvironment.MessageType.RecordNotFound;
                    break;
                case AppEnvironment.MessageType.PhoneNumberExists:
                    this.IsSuccess = false;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.PhoneNumberExists;
                    break;
                case AppEnvironment.MessageType.EmailExits:
                    this.IsSuccess = false;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.EmailExits;
                    break;
                case AppEnvironment.MessageType.RecordAlreadyExists:
                    this.IsSuccess = true;
                    this.Code = 409; //Conflict
                    this.MessageType = AppEnvironment.MessageType.RecordAlreadyExists;
                    break;
                case AppEnvironment.MessageType.ExceptionOccurred:
                    this.IsSuccess = false;
                    this.Code = 500;
                    this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
                    break;
                case AppEnvironment.MessageType.OperationSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.OperationSuccess;
                    break;
                case AppEnvironment.MessageType.InsertSuccess:
                    this.IsSuccess = true;
                    this.Code = 200; //201 de koyulabilir
                    this.MessageType = AppEnvironment.MessageType.InsertSuccess;
                    break;
                case AppEnvironment.MessageType.UpdateSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.UpdateSuccess;
                    break;
                case AppEnvironment.MessageType.DeleteSuccess:
                    this.IsSuccess = true;
                    this.Code = 200;
                    this.MessageType = AppEnvironment.MessageType.DeleteSuccess;
                    break;
                default:
                    this.IsSuccess = false;
                    this.Code = 500;
                    this.Exception = new ArgumentOutOfRangeException();
                    this.MessageType = AppEnvironment.MessageType.ExceptionOccurred;
                    break;
            }
        }

        public Result()
        {
        }

        public T Data { get; set; }
    }

    public enum MessageType
    {
        OperationFailed,
        OperationSuccess,
        InsertFailed,
        InsertSuccess,
        UpdateFailed,
        UpdateSuccess,
        DeleteFailed,
        DeleteSuccess,
        RecordNotFound,
        PhoneNumberExists,
        EmailExits,
        RecordAlreadyExists,
        ExceptionOccurred,
        Unauthorized,
        ContactUs
    }
}