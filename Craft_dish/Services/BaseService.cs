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
          //  ulong version = 10;

          // var config = new RealmConfiguration
          // {
          //  
          //     SchemaVersion = version,
          //     MigrationCallback = (migration, oldSchemaVersion) =>
          //     {
          //
          //        // migration.NewRealm.RemoveAll<Dish>();
          //      //   await UpdateRecommendationFromYourWebApi();
          //
          //         var newPeople = migration.NewRealm.All<Dish>();
          //         var oldPeople = migration.OldRealm.All("Dish");
          //
          //         for (var i = 0; i < newPeople.Count(); i++)
          //         {
          //             var oldPerson = oldPeople.ElementAt(i);
          //             var newPerson = newPeople.ElementAt(i);
          //
          //             // Migrate Person from version 0 to 1: replace FirstName and LastName with FullName
          //             if (version > 3)
          //             {
          //               //  newPerson.Name = oldPerson.Name;
          //             }
          //
          //            
          //         }
          //     }
          // };
          //
          // _realm = Realm.GetInstance(config);
        }

        public Realm getDbInstance()
        {
            return _realm;
        }

    }
}