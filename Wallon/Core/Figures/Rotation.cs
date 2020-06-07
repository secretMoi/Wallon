using System;

namespace Core.Figures
{
    public class Rotation
    {
        private double angle;
        private double angleDebut;
        private double angleFin;
        private bool sensRotation;
        private readonly double sensibiliteAngle;

        private const bool HORLOGIQUE = true;
        private const bool ANTI_HORLOGIQUE = false;
        
        public Rotation()
        {
            sensRotation = ANTI_HORLOGIQUE;
            sensibiliteAngle = 0.1;
        }
        
        public void SetRotation (double angleDebut, double angleFin)
        {
            this.angleFin = 360 - angleFin;
            this.angleDebut = 360 - angleDebut;
        }
        
        public Couple RotationPoint(Couple positionDepart, Couple point)
        {
            /*** calcul angle de la figure parente ***/
            
            Couple temp = new Couple();
            double angleRadian = DegreToRadian(angle);
            
            /*
             * x' = cos(theta)*(x-xc) - sin(theta)*(y-yc) + xc
             * y' = sin(theta)*(x-xc) + cos(theta)*(y-yc) + yc
             */

            temp.X = (int)(Math.Cos(angleRadian) * point.X - Math.Sin(angleRadian) * point.Y);
            temp.Y = (int)(Math.Sin(angleRadian) * point.X + Math.Cos(angleRadian) * point.Y);

            point.X = temp.X + positionDepart.X;
            point.Y = temp.Y + positionDepart.Y;

            return point;
        }

        public void Tourne(double pas)
        {
            if (sensRotation == HORLOGIQUE)
                angle += pas;
            else if(sensRotation == ANTI_HORLOGIQUE)
                angle -= pas;

            angle = CorrigeAngle(angle);

            if (angle <= angleFin)
                sensRotation = HORLOGIQUE;
            if (angle >= angleDebut)
                sensRotation = ANTI_HORLOGIQUE;
        }
        
        public void Position(double angle)
        {
            Angle = angle;
        }
        
        public static double DegreToRadian(double angle)
        {
            return angle * Math.PI / 180;
        }

        private double CorrigeAngle(double angle)
        {
            if (angle < 0.0)
                angle = 360.0 + angle;
            if (angle > 360.0)
                angle = angle - 360;

            return angle;
        }

        public double Angle
        {
            get => angle;
            set => angle = (360 - value) % 360;
        }

        public double AngleInverse()
        {
            return 360 - angle;
        }

        public double SensibiliteAngle => sensibiliteAngle;
    }
}