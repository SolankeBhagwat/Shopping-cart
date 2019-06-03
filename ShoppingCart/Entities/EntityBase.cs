using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public abstract class EntityBase
    {
        private readonly Guid _id;

        protected EntityBase() : this(GenerateGuidComb())
        {
        }

        protected EntityBase(Guid id)
        {
            _id = id;
        }

        public virtual Guid Id
        {
            get { return _id; }
        }

        private static Guid GenerateGuidComb()
        {
            var destinationArray = Guid.NewGuid().ToByteArray();
            var time = new DateTime(0x76c, 1, 1);
            var now = DateTime.Now;
            var span = new TimeSpan(now.Ticks - time.Ticks);
            var timeOfDay = now.TimeOfDay;
            var bytes = BitConverter.GetBytes(span.Days);
            var array = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333));
            Array.Reverse(bytes);
            Array.Reverse(array);
            Array.Copy(bytes, bytes.Length - 2, destinationArray, destinationArray.Length - 6, 2);
            Array.Copy(array, array.Length - 4, destinationArray, destinationArray.Length - 4, 4);
            return new Guid(destinationArray);
        }

        public virtual int Version { get; protected set; }

        #region Equality Tests

        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase
                && this == (EntityBase)entity;
        }

        public static bool operator ==(EntityBase base1,
            EntityBase base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            // check for either of them == to null
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (base1.Id != base2.Id)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return (!(base1 == base2));
        }

        public override int GetHashCode()
        {
            {
                return Id.GetHashCode();
            }
        }

        #endregion Equality Tests


    }
}
