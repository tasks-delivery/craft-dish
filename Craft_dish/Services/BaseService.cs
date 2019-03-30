using Craft_dish.Models;
using Realms;
using System.Linq;

namespace Craft_dish.Services
{
    public class BaseService
    {

        private readonly Realm _realm;

        public BaseService()
        {
            var config = new RealmConfiguration() { SchemaVersion = 10 };
            _realm = Realm.GetInstance(config);        
        }

        public Realm getDbInstance()
        {
            return _realm;
        }

    }
}
