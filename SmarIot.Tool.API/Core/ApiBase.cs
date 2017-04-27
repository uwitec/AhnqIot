using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using System;
using System.Collections.Generic;

namespace SmartIot.Tool.API.Core
{
    public class ApiBase
    {
        protected void Guard(AwEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.DataBlockObject == null) throw new NullReferenceException("entity.DO");
            if (entity.DataBlockObject.DataContentRequest == null)
                throw new NullReferenceException("entity.DO.DataContent");
        }

        protected List<T> ProcessXResponseMessage<T>(XResponseMessage response) where T : class
        {
            if (response.Success == ErrorType.NoError)
            {
                return response.Data;
            }
            else
            {
                return new List<T>();
            }
        }
    }
}