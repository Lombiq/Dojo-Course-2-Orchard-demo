using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement.Utilities;

namespace DojoCourse2.Module.Models
{
    public class PersonListPart : ContentPart<PersonListPartRecord>
    {
        public Sex Sex
        {
            get { return Retrieve(x => x.Sex); }
            set { Store(x => x.Sex, value); }
        }

        public int MaxCount
        {
            get { return Retrieve(x => x.MaxCount); }
            set { Store(x => x.MaxCount, value); }
        }

        private readonly LazyField<IEnumerable<PersonRecord>> _persons = new LazyField<IEnumerable<PersonRecord>>();
        internal LazyField<IEnumerable<PersonRecord>> PersonsField { get { return _persons; } }
        public IEnumerable<PersonRecord> Persons { get { return _persons.Value; } }
    }

    public class PersonListPartRecord : ContentPartRecord
    {
        public virtual Sex Sex { get; set; }
        public virtual int MaxCount { get; set; }


        public PersonListPartRecord()
        {
            MaxCount = 10;
        }
    }
}