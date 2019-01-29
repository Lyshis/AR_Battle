using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters {
	public class LizardMan : MonoBehaviour, ICharacter {
		[SerializeField] private int movement;
		[SerializeField] private int initiative;
		[SerializeField] private int health;
		[SerializeField] private int defense;

		public int GetMovement() { return movement; }
		public void DecreaseMovement(int slow) { movement -= slow; }
		public void IncreaseMovement(int speed) { initiative += speed; }
		
		public int GetInitiative() { return initiative; }
		
		public int GetHealth() { return health; }
		public void DecreaseHealth(int damages) { health -= damages; }
		public void IncreaseHealth(int heal) { health += heal; }

		public int GetDefense() { return defense; }
		public void DecreaseDefense(int defdown) { defense -= defdown; }
		public void IncreaseDefense(int defup) { defense += defup; }
	}
}

