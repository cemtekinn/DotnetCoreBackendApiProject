using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SettingManager : ISettingService
    {
        ISettingDal _settingDal;
        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }
        public IResult Add(Setting setting)
        {
            _settingDal.Add(setting);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
           Setting setting=_settingDal.Get(s=>s.Id==id);
           _settingDal.Delete(setting);
           return new SuccessResult();
        }

        public IDataResult<Setting> GetByKey(string key)
        {
            return new SuccessDataResult<Setting>(_settingDal.Get(s=>s.SettingKey==key));
        }

        public IDataResult<List<Setting>> GetAll()
        {
            return new SuccessDataResult<List<Setting>>(_settingDal.GetAll());
        }

       

        public IResult Update(string key, string value)
        {
            Setting setting=GetByKey(key).Data;
            setting.SettingValue = value;
            _settingDal.Update(setting);
            return new SuccessResult();
        }
    }
}
