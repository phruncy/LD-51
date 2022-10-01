using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class EnergyController : MonoBehaviour
    {

        private List<EnergyConsumer> _energyConsumers = new List<EnergyConsumer>();
        private List<EnergyProducer> _energyProducers = new List<EnergyProducer>();

        public int GetEnergyPerTick()
		{
            return _energyProducers.Sum(p => p.EnergyProduction);
        }

        public List<EnergyTarget> GetEnergyTargets()
		{
            List<EnergyTarget> result = new List<EnergyTarget>();
			IOrderedEnumerable<EnergyConsumer> orderedConsumers = _energyConsumers.OrderByDescending(c => c.Priority);
            int energyLeft = GetEnergyPerTick();

			foreach (EnergyConsumer consumer in orderedConsumers)
			{
                if (energyLeft <= 0)
                    break;
                int amount = Mathf.Min(energyLeft, consumer.RequiredEnergy);
                energyLeft -= amount;
                result.Add(new EnergyTarget
                {
                    Consumer = consumer,
                    EnergyAmount = amount
                });
            }

            return result;
        }

        public void Add(EnergyConsumer consumer)
		{
            _energyConsumers.Add(consumer);
        }

        public void Remove(EnergyConsumer consumer)
		{
            _energyConsumers.Remove(consumer);
        }

        public void Add(EnergyProducer producer)
		{
            _energyProducers.Add(producer);
        }

        public void Remove(EnergyProducer producer)
		{
            _energyProducers.Remove(producer);
        }

        public struct EnergyTarget
		{
            public EnergyConsumer Consumer;
            public int EnergyAmount;
        }
    }
}
