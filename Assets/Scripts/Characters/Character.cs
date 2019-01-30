using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters {
	public interface ICharacter {
		int GetMovement();
		void DecreaseMovement(int slow);
		void IncreaseMovement(int speed);
		
		int GetInitiative();
		
		int GetHealth();
		void DecreaseHealth(int damages);
		void IncreaseHealth(int heal);

		int GetDefense();
		void DecreaseDefense(int defdown);
		void IncreaseDefense(int defup);
	}
}

