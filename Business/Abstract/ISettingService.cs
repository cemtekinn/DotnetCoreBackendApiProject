using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISettingService
    {
        IDataResult<List<Setting>> GetAll();
        IDataResult<Setting> GetByKey(string key);

        IResult Add(Setting setting);
        IResult Update(string key,string value);
        IResult Delete(int id);
    }
}
