/*
    MIT License
    
    Copyright (c) [2019] [Daniel Denev and Orlin Dimitrov]
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

using System;
using System.Collections.Generic;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// Summary description for Planets.
    /// </summary>
    [Serializable]
    public class SolarSystemObjects : IList<SolarSystemObject>
    {
        private List<SolarSystemObject> storage = new List<SolarSystemObject>();

        public SolarSystemObjects()
        {

        }

        public SolarSystemObjects(List<SolarSystemObject> objects)
        {
            this.storage = objects;
        }

        #region Implementation of IList

        public int IndexOf(SolarSystemObject item)
        {
            return this.storage.IndexOf(item);
        }

        public void Insert(int index, SolarSystemObject item)
        {
            this.storage.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.storage.RemoveAt(index);
        }

        public SolarSystemObject this[int index]
        {
            get
            {
                return this.storage[index];
            }
            set
            {
                this.storage[index] = value;
            }
        }

        public void Add(SolarSystemObject item)
        {
            this.storage.Add(item);
        }

        public void Clear()
        {
            this.storage.Clear();
        }

        public bool Contains(SolarSystemObject item)
        {
            return this.storage.Contains(item);
        }

        public void CopyTo(SolarSystemObject[] array, int arrayIndex)
        {
            this.storage.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(SolarSystemObject item)
        {
            return this.storage.Remove(item);
        }

        public IEnumerator<SolarSystemObject> GetEnumerator()
        {
            return this.storage.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.storage.GetEnumerator();
        }

        #endregion

        public SolarSystemObject GetObjectByName(string name)
        {
            SolarSystemObject result = null;

            foreach (SolarSystemObject obj in this.storage)
            {
                if (obj.Name == name)
                {
                    result = obj;
                    break;
                }
            }

            return result;
        }
    }
}
