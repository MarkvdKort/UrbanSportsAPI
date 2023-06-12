using ImpactMeasurementAPI.Models;
using System;
using System.Collections.Generic;

namespace ImpactMeasurementAPI.Mapper
{
    public class MomentarilyAccelerationMapper
    {
        class Calculator
        {
            //Easy function to get the square of a number
            public double GetSquare(double number)
            {
                return number * number;
            }
        }
        Calculator math = new Calculator();
        public List<MomentarilyAccelerationWithPlayerLoad> MapMomentarilyAccelerationToMomentarilyAccelerationWithPlayerLoad(List<MomentarilyAcceleration> momentarilyAccelerations)
        {
            //Create a List of the new object
            List<MomentarilyAccelerationWithPlayerLoad> momentarilyAccelerationWithPlayerLoads = new List<MomentarilyAccelerationWithPlayerLoad>();

            for (int i = 0; i < momentarilyAccelerations.Count; i++)
            {
                //if there is a previous acceleration
                if (i > 1) 
                {
                    MomentarilyAccelerationWithPlayerLoad accelerationWithPlayerLoad = new MomentarilyAccelerationWithPlayerLoad()
                    {
                        AccelerationX = momentarilyAccelerations[i].AccelerationX,
                        AccelerationY = momentarilyAccelerations[i].AccelerationY,
                        AccelerationZ = momentarilyAccelerations[i].AccelerationZ,
                        Id = momentarilyAccelerations[i].Id,
                        TrainingSession = momentarilyAccelerations[i].TrainingSession,
                        TrainingSessionId = momentarilyAccelerations[i].TrainingSessionId,
                        Frame = momentarilyAccelerations[i].Frame,
                        PlayerLoad = 
                        Math.Sqrt((math.GetSquare((momentarilyAccelerations[i].AccelerationX - momentarilyAccelerations[i - 1].AccelerationX)) 
                        + math.GetSquare(momentarilyAccelerations[i].AccelerationY - momentarilyAccelerations[i - 1].AccelerationY) 
                        + math.GetSquare(momentarilyAccelerations[i].AccelerationZ - momentarilyAccelerations[i - 1].AccelerationZ)))
                    };
                    momentarilyAccelerationWithPlayerLoads.Add(accelerationWithPlayerLoad);
                }

                //If there isn't a previous acceleration you don't have to subtract anything
                else 
                {
                    MomentarilyAccelerationWithPlayerLoad accelerationWithPlayerLoad = new MomentarilyAccelerationWithPlayerLoad()
                    {
                        AccelerationX = momentarilyAccelerations[i].AccelerationX,
                        AccelerationY = momentarilyAccelerations[i].AccelerationY,
                        AccelerationZ = momentarilyAccelerations[i].AccelerationZ,
                        Id = momentarilyAccelerations[i].Id,
                        TrainingSession = momentarilyAccelerations[i].TrainingSession,
                        TrainingSessionId = momentarilyAccelerations[i].TrainingSessionId,
                        Frame = momentarilyAccelerations[i].Frame,
                        PlayerLoad =
                        Math.Sqrt((math.GetSquare((momentarilyAccelerations[i].AccelerationX))
                        + math.GetSquare(momentarilyAccelerations[i].AccelerationY)
                        + math.GetSquare(momentarilyAccelerations[i].AccelerationZ)))
                    };
                    momentarilyAccelerationWithPlayerLoads.Add(accelerationWithPlayerLoad);
                }
                
            }
            return momentarilyAccelerationWithPlayerLoads;

        }
    }
}

