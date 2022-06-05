# MicroserviceDemo
This is a _**demo**_ project to learn about **microservices**.
<br />
It contains two services, which are contenerized with **Docker** and deployed with **Kubernetes**.
Services commmunicate with each other within a k8s cluster and are exposed through an Ingress **NGINX** Load Balancer.
The data is stored in a **MSSQL DB**, which is also contenerized and configured in k8s.
<br />
I wrote the details about the architecutre below.

## Overview of microservices in this Demo
The "Platform" Service:
- Function as an "Asset Register".
- Track all the platforms/systems in the company.

The "Commands" Service:
- Function as a repository of command line arguments for given Platforms.
- Aid in the automation of support process.

## Solution Architecture
![Solution Architecture png is under DemoDescription/Solution_Architecture_01.png](https://raw.githubusercontent.com/Jopa-Przemyslaw/MicroserviceDemo/master/DemoDescription/Solution_Architecture_01.png?token=GHSAT0AAAAAABVFZKJY5NH5Q6MCZTJBJDOKYU46B4A)

## Platform Service Architecture
![Platform Service Architecture png is under DemoDescription/PlatformService_Architecture_01.png](https://raw.githubusercontent.com/Jopa-Przemyslaw/MicroserviceDemo/master/DemoDescription/PlatformService_Architecture_01.png?token=GHSAT0AAAAAABVFZKJZVTHBVT3OIMNA2POSYU46EWQ)

## Command Service Architecture
![Platform Service Architecture png is under DemoDescription/CommandService_Architecture_01.png](https://raw.githubusercontent.com/Jopa-Przemyslaw/MicroserviceDemo/master/DemoDescription/CommandService_Architecture_01.png?token=GHSAT0AAAAAABVFZKJY5JU4DE4ZW7UM3ZSWYU46GPQ)

## Docker and Kubernetes
![Platform Service Architecture png is under DemoDescription/Kubernetes_Architecture_01.png](https://raw.githubusercontent.com/Jopa-Przemyslaw/MicroserviceDemo/master/DemoDescription/Kubernetes_Architecture_01.png?token=GHSAT0AAAAAABVFZKJZ2ZRIAOVQRNARHYQIYU46JYQ)

Thats all. Thanks for noticing, best!
<br />
Source of the topic: [@binarythistle](https://www.youtube.com/watch?v=DgVjEo3OGBI) Thanks to you I've learned a lot. Appreciate your work!
