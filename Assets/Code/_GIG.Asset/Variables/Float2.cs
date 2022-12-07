using System;

namespace Code._GIG.Asset.Variables
{
    [Serializable]
    public struct Float2
    {
        public float min;
        public float max;

        public Float2(float min, float max)
        {
            this.max = max;
            this.min = min;
        }
    }
}