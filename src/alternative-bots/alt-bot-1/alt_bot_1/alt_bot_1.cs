using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;


public class alt_bot_1 : Bot
{
    private bool radarSwingRight = true;
    static void Main(string[] args)
    {
        new alt_bot_1().Start();
    }

    alt_bot_1() : base(BotInfo.FromFile("alt_bot_1.json")) { }

    public override void Run()
    {
        // Set colors
        BodyColor = Color.White;
        GunColor = Color.White;
        RadarColor = Color.White;
        TracksColor = Color.White;
        TurretColor = Color.White;
        ScanColor = Color.White;

        AdjustRadarForGunTurn = false;
        AdjustGunForBodyTurn = true;

        while(IsRunning){
            
            
            for (int i = 0; i< 3 ;i++){
                SetTurnGunRight(double.PositiveInfinity);
                SetTurnLeft(360);
                MaxSpeed = 7;
                Forward(100);
            }
        }
        
    }

    public override void OnHitBot(HitBotEvent e)
    {
        if (e.IsRammed){
            double bearing = BearingTo(e.X, e.Y);
            SetTurnGunLeft(bearing);
            if (e.Energy <= 30 && Energy >65){
                SetFire(3);
                Forward(40);
            }
            else if(e.Energy <= 20 && Energy >40){
                SetFire(3);
                Forward(40);
            }
            else if (e.Energy <= 10 && Energy >30){
                SetFire(3);
                Forward(40);
            }
        }

    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
            // Keep gun+radar locked on the target
            double gunTurn = GunBearingTo(e.X, e.Y);
            SetTurnGunRight(2);
            

            if (radarSwingRight)
            {
                SetTurnGunRight(gunTurn + 100);
                SetTurnGunRight(gunTurn + double.PositiveInfinity);
            }
            else
            {
                SetTurnGunRight(gunTurn - 100);
                SetTurnGunRight(gunTurn - double.PositiveInfinity);
            }
            
            radarSwingRight = !radarSwingRight;
        double distance = DistanceTo(e.X, e.Y);
           
            if (distance < 200){
                SetFire(Math.Min(3.0, Energy * 0.5));
            }
            else if (distance < 400){
                SetFire(2);
            }
            else{
                SetFire(1);
            }
    }
    public override void OnHitWall(HitWallEvent e)
    {
        SetForward(-100);
        SetTurnLeft(-50);
        SetTurnRight(-50);
    }
    private void TurnToFaceTarget(double x, double y)
    {
        double angleToTarget = DirectionTo(x, y);
        double gunTurn = NormalizeRelativeAngle(angleToTarget - GunDirection); 
        double bodyTurn = NormalizeRelativeAngle(angleToTarget - Direction); 

        SetTurnGunLeft(gunTurn); 
        SetTurnLeft(bodyTurn); 
    }
}
