#Assignment 2

Team Memebers: Hans Prieto, Logan Levitre, Joshua Fawcett
===============================================================
Note for Graders: You might have to go to Assets/Reimport All after pulling, because some stuff might be missing after pulling the repository.

Contributions:

Logan Levitre: Player Characters Parts 1 and 2, and Dot Product gameplay element

Hans Prieto: The Camera, Ending the Game, Audio, and Particle Effect

Joshua Fawcett: Enemies Parts 1 and 2, and Linear Interpolation gameplay element

*dot product - Using Triggers  to turn on a script which uses dot product to get the distance to the ghost in the bathtub.
after activating the script, as the player gets close enough it will trigger an alert of !!! above the players head if getting to close to the tub.
The trigger to turn on the script is in front of the door and the trigger to turn it off is in the walkway towards the patrolling ghost in the hall.

*linear interpolation - The linear interpolation feature was added by creating some eyes on the wall that disappear when the player is too far away
and follow the player as they go past them.
	- The eyes use linear interpolation in order to set the alpha of their color to make them fade
        - The eyes also use linear interpolation to determine the position of the pupils within the eye when looking at the player

*particle effect - Every time the player enters a doorway, it will spawn a black smoke beneath that doorway for approximately 5 seconds.
