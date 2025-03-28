using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class alt_bot_2 : Bot
{   
    static void Main(string[] args)
    {
        new alt_bot_2().Start();
    }
    alt_bot_2() : base(BotInfo.FromFile("alt_bot_2.json")) { }

    public override void Run()
    {
        BodyColor = Color.Green;
        TurretColor = Color.Green;
        RadarColor = Color.Green;
        ScanColor = Color.Green;

        AdjustRadarForGunTurn = true;
        AdjustGunForBodyTurn = true;
        AdjustRadarForBodyTurn = true;

        while (IsRunning)
        {
            SetTurnRadarLeft(360);
            SetTurnLeft(45);
            SetForward(100);
            SetTurnRight(90);
            SetForward(100);
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        Console.WriteLine("I see a bot at " + e.X + ", " + e.Y);

        double distance = DistanceTo(e.X, e.Y);
        double firepower;

        if (distance < 200)
            firepower = Math.Min(3.0, Energy * 0.5);
        else if (distance < 400)
            firepower = 2.0;
        else
            firepower = 1.0;

        double gunTurn = NormalizeRelativeAngle(DirectionTo(e.X, e.Y) - GunDirection);
        SetTurnGunLeft(gunTurn);

        if (GunHeat == 0 && Energy > firepower)
            SetFire(firepower);
    }

    public override void OnHitByBullet(HitByBulletEvent e)
    {
        Random random = new Random();
        SetTurnRight(90 + random.Next(-30, 30));
        SetForward(150 + random.Next(50));
    }

    public override void OnHitBot(HitBotEvent e)
    {
        Console.WriteLine("Ouch! I hit a bot at " + e.X + ", " + e.Y);

        if (e.IsRammed) 
        {
            SetBack(50); 
            SetTurnRight(30); 
        }

        if (GunHeat == 0 && Energy > 1.0) 
        {
            SetFire(1.0);
        }

        Go();
    }

    public override void OnHitWall(HitWallEvent e)
    {
        Console.WriteLine("Ouch! I hit a wall, must turn back!");
        
        Stop();
        SetBack(50); 
        SetTurnRight(90); 
        Go();
    }
}