using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class AltBot1 : Bot
{
    static void Main(string[] args)
    {
        new AltBot1().Start();
    }

    AltBot1() : base(BotInfo.FromFile("AltBot1.json")) { }

    public double eX = 0, eY = 0, eSpeed = 0, eFacing = 0, eDistance = double.MaxValue;
    public int directionToMove = 1, eID = -1;

    public override void Run()
    {
        BodyColor = Color.Blue;
        GunColor = Color.Red;
        RadarColor = Color.Yellow;
        TracksColor = Color.Gray;
        TurretColor = Color.DarkRed;
        ScanColor = Color.Green;

        AdjustGunForBodyTurn = true;
        AdjustRadarForGunTurn = true;
        AdjustRadarForBodyTurn = true;

        while (IsRunning)
        {
            handleRadar();
            handleGun();
            handleMove();
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e) 
    { 
        double scannedDistance = DistanceTo(e.X, e.Y);

        if (eID == -1 || scannedDistance < eDistance - 20)
        {
            eID = e.ScannedBotId;
            eX = e.X;
            eY = e.Y;
            eDistance = scannedDistance;
        }
        else if (eID == e.ScannedBotId)
        {
            eX = e.X;
            eY = e.Y;
            eDistance = scannedDistance;
        }
    }

    public override void OnHitWall(HitWallEvent e)
    {
        Console.WriteLine("ouch wall");
        directionToMove *= -1;
    }

    public override void OnHitBot(HitBotEvent e)
    {
        Console.WriteLine("ouch rammed");
    }

    public override void OnBotDeath(BotDeathEvent e)
    {
        if (e.VictimId == eID)
            eID = -1;
    }

    public void handleRadar()
    {
        SetTurnRadarLeft(360);
    }

    public void handleGun() 
    {
        double firepower;
        if (eDistance < 200)
            firepower = Math.Min(3.0, Energy * 0.5);
        else if (eDistance < 400)
            firepower = 2.0;
        else
            firepower = 1.0;
            
        double gunTurn = NormalizeRelativeAngle(DirectionTo(eX, eY) - GunDirection);
        SetTurnGunLeft(gunTurn);

        if (GunHeat == 0 && Energy > firepower) 
            SetFire(firepower);
    }

    public void handleMove()
    {
        double bodyTurn = DirectionTo(eX, eY) - Direction;
        int moveForward;

        if (eDistance < 150)
        {
            // too close
            bodyTurn += 90;
            moveForward = -100;
        }
        else if (eDistance > 400)
        {
            // too far
            moveForward = 100;
        }
        else
        {
            // circle around
            bodyTurn += 90;
            moveForward = 50;
        }
        SetTurnLeft(NormalizeRelativeAngle(bodyTurn));
        SetForward(moveForward * directionToMove);
    }
}
