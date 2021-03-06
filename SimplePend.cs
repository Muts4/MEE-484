// ======================================================================== //
// SimplePend.cs Defines a class for simulating a simple pendulum //
// ======================================================================== //

using System;

namespace Sim
{
    public class SimplePend
    {
        private double len = 1.1; // pendulum length
        private double g = 9.81; // gravitational field
        int n = 2;          // number of states
        private double[] x;  // Array of states
        private double[] f;  // right side of equation evaluated


        // ---------------------------------------------------------------- //
        // Constructor 
        // ---------------------------------------------------------------- //

        public SimplePend()
        {
          x = new double[n];
          f = new double[n]; 

          x[0] = 1.0;
          x[1] = 0.0;
        }

        // ---------------------------------------------------------------- //
        // step: perform one integration step via Euler's Method
        // ---------------------------------------------------------------- //
        public void step(double dt)
        {
            rhsFunc(x,f);
            int i;
            for(i=0;i<n;++i)
            {
                x[i] = x[i] + f[i] * dt;
            }
           // Console.WriteLine($"{f[0].ToString()}   {f[1].ToString()}");
        }

        // ---------------------------------------------------------------- //
        // rhsFunc: Function to calculate rhs of pendulum ODEs
        // ---------------------------------------------------------------- //
        public void rhsFunc(double[] st, double[] ff)
        {
            ff[0] = st[1];
            ff[1] = -g/len * Math.Sin(st[0]);
        }




        // ---------------------------------------------------------------- //
        // Getters and Setters
        // ---------------------------------------------------------------- //
        public double L
        {
            get {return(len);}

            set
            {
                if(value > 0.0)
                    len = value;
            }
        }
        public double G
        {
            get {return(g);}

            set
            {
                if(value >= 0.0)
                    g = value;
            }
        }

        public double theta
        {
            get {return x[0];}

            set { x[0] = value;}      
        }

        public double thetaDot
        {
            get {return x[1];}

            set { }
        }

    }

}