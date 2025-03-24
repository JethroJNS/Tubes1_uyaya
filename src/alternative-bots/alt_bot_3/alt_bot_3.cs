using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;


public class alt_bot_3 : Bot
{
    static void Main(string[] args)
    {
        new alt_bot_3().Start();
    }

    alt_bot_3() : base(BotInfo.FromFile("alt_bot_3.json")) { }

    public override void Run()
    {
        BodyColor = Color.Yellow;
        GunColor = Color.Yellow;
        RadarColor = Color.Yellow;
        TracksColor = Color.Yellow;
        TurretColor = Color.Yellow;
        ScanColor = Color.Yellow;
    
        AdjustGunForBodyTurn = true;
        AdjustRadarForGunTurn = true;
        AdjustRadarForBodyTurn = true;


        while(IsRunning){
            SetTurnRadarRight(10_000);
            SetTurnLeft(200);
            Forward(200);
            SetTurnRight(200);
            Forward(200);
            Go();
        }
        
    }

    public override void OnHitBot(HitBotEvent e)
    {
        SetTurnLeft(-50);
        SetTurnRight(50);
        TurnToFaceTarget(e.X, e.Y);
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        double gunTurn = NormalizeRelativeAngle(DirectionTo(e.X, e.Y) - GunDirection);
        SetTurnGunLeft(gunTurn);
        double distance = DistanceTo(e.X, e.Y);
        if (distance < 100){
            SetFire(3);
        }
        else if (distance < 200){
            SetFire(2);
        }
        else{
            SetFire(1);
            SetFire(1);
        }
    }
        public override void OnHitWall(HitWallEvent e)
    {
        SetTurnLeft(-100);
        SetTurnRight(-100);
    }

    private void TurnToFaceTarget(double x, double y)
    {
        double angleToTarget = DirectionTo(x, y); 
        double gunTurn = NormalizeRelativeAngle(angleToTarget - GunDirection);
        double bodyTurn = NormalizeRelativeAngle(angleToTarget - Direction); 
        SetTurnGunLeft(gunTurn); 
        SetTurnRadarRight(0);
        SetFire(3);
        SetFire(2);
        SetTurnRadarRight(10_000);

    }
}
