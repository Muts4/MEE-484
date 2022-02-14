// ======================================================================== //
// SimplePend.cs Defines a class for simulating a simple pendulum //
// // ======================================================================== //
using System;

namespace Sim
{
    public class SimplePendRK4
    {
        private double len = 1.1; // pendulum length
        private double g = 9.81; // gravitational field
        int n = 2;          // number of states
        private double[] x;  // Array of states
        private double[] f;  // right side of equation evaluated
        private double dx1;
        private double dx2;
        private double dx3;
        private double dx4;
        
        // ---------------------------------------------------------------- //
        // Constructor 
        // ---------------------------------------------------------------- //

    public SimplePendRK4()
        {
             x = new double[n];
             f = new double[n]; 

            
            x[0] = 1.0;
            x[1] = 0.0;
    }
    public void step(double dt)
    {
        rk4func(x,f);
        int i = 0;
        while(i < x.Length - 1)
        {
            dx1 = dt * rk4func(f[i], x[i]);
            dx2 = dt * rk4func(f[i] + dt / 2, x[i] + dx1 / 2);
            dx3 = dt * rk4func(f[i] + dt / 2, x[i] + dx2 / 2);
            dx4 = dt * rk4func(f[i] + dt, x[i] + dx3);

            f[i + 1] = f[i] + dt;
            x[i + 1] = x[i] + (dx1 + 2 * dx2 + 2 * dx3 + dx4) / 6;
        }
    }
    public void rk4func(double[] st, double[] ff)
    {
        ff[0] = st[1];
        ff[1] = -g/len * Math.Sin(st[0]);
    }
    }

    //---------------------------------------------------------------- //
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

            set {x[1] = value; }
        }

    }




