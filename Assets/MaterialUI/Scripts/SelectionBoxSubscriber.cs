//  Copyright 2014 Invex Games http://invexgames.com
//	Licensed under the Apache License, Version 2.0 (the "License");
//	you may not use this file except in compliance with the License.
//	You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//	Unless required by applicable law or agreed to in writing, software
//	distributed under the License is distributed on an "AS IS" BASIS,
//	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//	See the License for the specific language governing permissions and
//	limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace MaterialUI
{
	public class SelectionBoxSubscriber : MonoBehaviour
	{
		SelectionBoxConfig config;
		public UnityEvent OnValueChange;
		void OnEnable ()
		{
			//	Example of what you can do when an item is selected
			config = gameObject.GetComponent<SelectionBoxConfig> ();
			config.ItemPicked += DoThing;
		}

		void OnDisable ()
		{
			config.ItemPicked -= DoThing;
		}

		void DoThing (int id)
		{
			OnValueChange.Invoke();
			Debug.Log ("'" + config.listItems[id] + "' picked, ID: " + id);
		}
	}
}
