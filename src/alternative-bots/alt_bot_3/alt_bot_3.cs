using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;


public class alt_bot_3 : Bot
{
    private int targetBotId = -1; // Track a specific enemy bot
    // The main method starts our bot
    static void Main(string[] args)
    {
        new alt_bot_3().Start();
    }

    // Constructor, which loads the bot settings file
    alt_bot_3() : base(BotInfo.FromFile("alt_bot_3.json")) { }

    // Called when a new round is started -> initialize and start scanning
    public override void Run()
    {
        // Set colors
        BodyColor = Color.Yellow;
        GunColor = Color.Yellow;
        RadarColor = Color.Yellow;
        TracksColor = Color.Yellow;
        TurretColor = Color.Yellow;
        ScanColor = Color.Yellow;
    
        // Make gun and radar turn together
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
