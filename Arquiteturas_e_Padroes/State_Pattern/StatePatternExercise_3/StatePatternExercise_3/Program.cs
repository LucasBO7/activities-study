using StatePatternExercise_3.Entities;
using StatePatternExercise_3.Entities.States;

TrafficLight semaforo = new();

semaforo.Change(); // 🔵 O sinal mudou para VERDE! Os carros podem andar.
semaforo.CurrentLightState = new GreenState();
semaforo.Change(); // 🟡 O sinal mudou para AMARELO! Atenção!
semaforo.CurrentLightState = new YellowState();
semaforo.Change(); // 🔴 O sinal mudou para VERMELHO! PARE!
semaforo.CurrentLightState = new RedState();
semaforo.Change(); // 🔵 O sinal mudou para VERDE! Os carros podem andar.