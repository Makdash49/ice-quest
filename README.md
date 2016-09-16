# Ice Quest

Launching into my own Virtual Reality

“Not all those who wander are lost.”
― J.R.R. Tolkien

I want to share with you the adventure I’m having creating my first virtual reality game. It’s called “Ice Quest” and an in-progress version is currently available on the Oculus store, with special access. Email me at markdmcq@gmail.com and tell me your Oculus username, and I will give you access to the Alpha version of the game for Samsung Gear VR.

My desire to make a virtual reality game was sparked when I landed a job with River Studios, a talented team of storytellers and virtual reality content creators. As a Quality Assurance Developer with the team I spend a significant amount of time testing virtual reality experiences and have had the opportunity to see what works and what does not. I also get to discover what I find most fun.

For my first game, I wanted to build a simple project that plays to the strengths of virtual reality. First and foremost I wanted to capitalize on the sense of presence, which means immersing the player in a new and engaging place and making them feel like they’re really there. Secondly, I wanted to give the player the agency to explore the environment and affect things in it in meaningful ways. I was particularly inspired by the VR game “Land’s End”.  

Land’s End:  http://www.landsendgame.com/

I took a number of online tutorials focusing on the Unity game engine and developing for virtual reality. By following a tutorial step by step I made a “Frogger” themed VR game.
  
Udemy: Make VR Games in Unity with C# — Cardboard, Gear VR, Oculus(https://www.udemy.com/vrcourse/)

At one point in the tutorial I had not perfected the frog’s jumping mechanic. I was able to jump while already in mid-air. By jumping repeatedly in quick succession I could fly high above the ground. I discovered this was really fun because I enjoyed the sense of height and freedom. I believed this was a good starting point for my own game.

I imagined flying through a mysterious and surreal landscape. This could foster the sense of awe and wonder that I most enjoy in virtual reality while also having fewer polygons to render than say a detailed cityscape. This would ensure smooth performance by a computer processor and prevent jerkiness or judder as the player flies along. I also imagined that if I created a landscape that was more abstract it would actually be more immersive than one that is fairly realistic. This is similar to the phenomenon of the “Uncanny Valley” whereby “a computer-generated figure or humanoid robot bearing a near-identical resemblance to a human being arouses a sense of unease or revulsion in the person viewing it.” (Google definition) In a nutshell, the more realistic something is the more attention it draws to the ways in which it is not real.

I decided I would design my game for the Samsung Gear VR so that I could easily show my creation to my friends and family. Gear VR is much easier to throw in a backpack and walk across town or take on a road trip than the Oculus Rift or the Vive which both require a powerful workstation. The drawback is I would be limited to the processing power of an Android smartphone. But I felt this was an appropriate limitation as it would force me to keep it simple.

I was able to find a 3D icebergs asset for sale on the Unity store in a package called “PolyWorld Vistas”. I imported the icebergs asset into the Unity editor and stretched it out and then made a copy of it and used it to intersect the original icebergs asset perpendicularly. I added a ground plane. This resulted in an engaging landscape of nooks and crannies, of tight caves and majestic vistas. I added a sky of stars with a splash of the Milky Way which greatly enhanced the impression of vastness.

PolyWorld Vistas: https://www.assetstore.unity3d.com/en/#!/content/34775

To design a mechanism that would allow a player to explore this environment, I wanted to leverage my impressions of numerous virtual reality experiences I had looked at such as “Land’s End”, “Ocean Rift”, and “Temple Run”. I had noticed some forms of game locomotion gave me motion sickness. I felt nausea when there was a distinct difference between the way I saw myself moving and how I felt myself moving in real life. I felt the most sick in VR when I was moving rapidly in a curve. When you move in a curve in reality, you feel a distinct sensation of centripetal force. You sense momentum pushing you outward from the center of the curve. When you move in a curve in VR you don’t feel this centripetal force and the conflict between what you see and what you feel persuades your body that you are sick and may need to throw up to clean out your system. I hypothesized that if I kept the motion in my game to straight lines, I could minimize queasiness.

Some VR games allow you to travel forward but when you look to the left or the right, you swerve forward in that direction. This causes the player to move in nausea-inducing curved lines. I decided I would not do that in “Ice Quest”. I would allow the player to head in one direction while being free to look around without changing direction just as when one is driving a car or taking a walk.

I implemented a simple to use locomotion mechanic in which the user taps the touch pad on the side of the Gear VR to travel in the direction they are looking at that moment. This allows the user to easily fly forward and back, up and down with a great deal of freedom. They can look around as they are travelling without changing direction. With this mechanic, I thoroughly enjoyed exploring my new and surprisingly beautiful environment but I wanted “Ice Quest” to have some purpose so I added ten red cubes for the player to search for. I put some in plain sight, others behind corners, and others hidden in deep crevasses. To make the cubes interactive I made them become blue and chime when the player collides with them. It became an Easter Egg Hunt to find and transform all the cubes. “Ice Quest” was ready to share with my co-workers and friends!

So began the process of observing their play and listening to their feedback. I am happy to say that overall they enjoyed it. The first thing I noticed is that people would find two or three cubes and then exit the game. I wondered if people would be more engaged if I added a counter that expressed the number of found cubes, for example “2 of 10”. I implemented it and sure enough players were much more inclined to try to find all 10 cubes. A number of players expressed their impatience with the speed at which they moved in the game. They wanted to be able to move faster. So I updated the locomotion mechanic so that the more a player tapped the touch pad the faster they went. They could reset their speed by colliding with a cube, an iceberg, or the ground.

The feedback on this iteration was very encouraging. I felt a sense of accomplishment. Although “Ice Quest” was a very simple game, it was fun. River Studios’ Design Director, Christian Talmage, told me that this is better than what often happens in the video game industry, when a very complicated game is created, but it’s not fun. When a game is very complicated it’s hard to tell why it’s not fun and what can be changed to make it fun.

I had overcome many technical challenges to get to this point but I realized that there was a whole realm of challenge that I had yet to venture into. I needed to meet specifications set out by Oculus or I would not be able to distribute the game on the Oculus store. My strategy to better understand the Oculus requirements and submission process was to go ahead and submit “Ice Quest” to the store.

To be Continued…
