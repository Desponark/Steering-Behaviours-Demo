# Steering Behaviours Demo

This is intended as a little demonstration (and experimentation) of the different Steering Behaviours mentioned in the book _"Programming Game AI by Example by Mat Buckland"_ at chapter 3 _"How to Create Autonomously Moving Game Agents"_.

It also serves the purpose of a testbed for a private godot project I'm working on with a friend.

## Engine / Language
- Godot 4.1 Mono / C#

## Theory behind it
> The movement of an autonomous agent can be broken down into three
layers:
- Action Selection:
  > This is the part of the agent’s behavior responsible for choosing its goals and deciding what plan to follow. It is the part that says “go here” and “do A, B, and then C.”

	- This is implemented [here](https://github.com/Desponark/Steering-Behaviours-Demo/blob/master/Scripts/ActionSelection/ActionSelection.cs) in a very simple way in order to focus on the Steering Behaviours themselves.
 	- Right now target positions are set via mouse click. Target Vehicles need to be manually added in the "Action Selection" node.
  - ![image](https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/022babe8-99c7-4c02-acc2-b75923775860)

- Steering
  > This layer is responsible for calculating the desired trajectories required to satisfy the goals and plans set by the action selection layer. Steering behaviors are the implementation of this layer. They produce a steering force that describes where an agent should move and how fast it should travel to get there.

	- It often makes sense to combine different Steering Behaviours to get _emergent behaviour_. [Here](https://github.com/Desponark/Steering-Behaviours-Demo/blob/master/Scripts/Steering/Steering.cs) they are combined as a weighted truncated running sum with priorization.
 	- In Godot the desired Steering Behaviours can simply be added as nodes and sorted by prio and adjusted with individual weights.
 	- ![image](https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/a5a2523e-4dfe-46ed-ba53-9571df742b5e) ![image](https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/e0b665a2-ccec-49c0-9380-06862ad16914)
  
- Locomotion
  > The bottom layer, locomotion, represents the more mechanical aspects of an agent’s movement. It is the how of traveling from A to B.
  For example, if you had implemented the mechanics of a camel, a tank, and a goldfish and then gave a command for them to travel north, they would all use different mechanical processes to create motion even though their intent (to move north) is identical.
  By separating this layer from the steering layer, it’s possible to utilize, with little modification, the same steering behaviors for completely different types of locomotion.

	- **There is currently a mistake with how the steering force is added to the velocity. Instead of adding to the velocity every frame it gets set to the velocity. This leads to widly different behaviour than is actually wanted/expected. I am working on another project that has this mistake corrected and will be public soon.**
  	- This [class](https://github.com/Desponark/Steering-Behaviours-Demo/blob/master/Scripts/Vehicle.cs) serves as the locomotion and where the resulting Steering Force is consumed by Godot's MoveAndSlide() function.
 	- ![image](https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/06999ff3-117e-42f0-b37f-005bd4af729c)

## Steering Behaviours
Steering Behaviours are found [here](https://github.com/Desponark/Steering-Behaviours-Demo/tree/master/Scripts/Steering/SteeringBehaviour/Behaviours)

### Seek
Calculates a steering force that directs an agent towards a target position.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/d85ac4ea-df62-409d-a65a-71dd2324b177

### Flee
Calculates a steering force that steers an agent away from the target position.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/9d173773-8292-4334-a974-5206d2f0e441

### Arrive
Calculates a steering force that decelerates an agent onto a target position.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/2dd9938b-79d3-484a-9631-443339ec7f16

### Pursuit
Calculates a steering force that steers towards the predicted position of an agent.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/f14cceef-75ff-4152-9265-b58fcbc029fb

### Evade
Calculates a steering force that steers away from the predicted position of an agent.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/c61fad42-e8a2-4d9c-ad4c-74e39e8d79f1

### Wander
Calculates a steering force that makes an agent wander around by projecting a circle in front of it and steering towards a target position that is constrained to move along the circle perimeter.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/b1abbf7c-ad26-4140-8807-5a293fc2c4bf

### Obstacle Avoidance
Calculates a steering force that steers an agent to avoid obstacles lying in its path.
- Not yet Implemented

### Wall Avoidance
Calculates a steering force that directs an agent away from walls.
- Not yet Implemented

### Interpose
Calculates a steering force that moves an agent to the midpoint of the imaginary line connecting two other agents/positions
- Not yet Implemented

### Hide
Calculates a steering force that steers an agent so that there is always an obstacle between it and another agent.
- Not yet Implemented

### FollowPath
Calculates a steering force that moves an agent along a series of positions
- Not yet Implemented

### Offset Pursuit
Calculates a steering force required to keep an agent at a specified offset from a target agent.

https://github.com/Desponark/Steering-Behaviours-Demo/assets/129955348/27fcd2ed-cb6c-426e-b312-da65cb4f21d2

## Group Behaviours
Group Behaviours are found [here](https://github.com/Desponark/Steering-Behaviours-Demo/tree/master/Scripts/Steering/SteeringBehaviour/GroupBehaviours).
Group Behaviours are special as they take into consideration the other agents in the game.

### Separation
Calculates a steering force that keeps an agents heading (look direction) aligned with its neighbors
- Not yet Implemented

### Alignment
Calculates a steering force that directs an agent away from neighbouring agents
- Not yet Implemented

### Cohesion
Calculates a steering force that directs an agent toward the center of mass of its neighbours
- Not yet Implemented

## Note
- All quotes are from the book _"Programming Game AI by Example by Mat Buckland"_ and mostly from chapter 3 _"How to Create Autonomously Moving Game Agents"_.
