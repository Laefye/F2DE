using F2DE.Base.Interfaces;
using F2DE.Base.Registries;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base
{
    internal class Registry : IDisposable
    {

        private List<RegisterValue> registerValues = new List<RegisterValue>();

        public T Register<T>(T value) where T : RegisterValue
        {
            registerValues.Add(value);
            return value;
        }

        public List<T> GetValues<T>() where T : RegisterValue
        {
            var registries = new List<T>();
            foreach (var value in registerValues)
            {
                if (value.GetType().IsAssignableTo(typeof(T)))
                {
                    registries.Add((T)value);
                }
            }
            return registries;
        }

        public T? GetValue<T>() where T : RegisterValue
        {
            foreach (var value in registerValues)
            {
                if (value.GetType().IsAssignableTo(typeof(T)))
                {
                    return (T) value;
                }
            }
            return null;
        }

        public T? GetResource<T>(string name) where T : Resource
        {
            foreach (var value in registerValues)
            {
                if (value.GetType().IsAssignableTo(typeof(T)) && ((Resource) value).name == name)
                {
                    return (T)value;
                }
            }
            return null;
        }

        public void Dispose()
        {
            foreach (var value in registerValues)
            {
                if (value.GetType().IsAssignableTo(typeof(IDisposable)))
                {
                    ((IDisposable)value).Dispose();
                }
            }
        }
    }
}
