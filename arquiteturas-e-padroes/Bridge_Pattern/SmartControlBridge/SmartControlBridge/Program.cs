/* Sistema de controle de dispositivos inteligentes
 * Podem ser controlados por diferentes controles
 * 
 * Dispositivos -> múltiplos (TVs, Lâmpadas...)
 * Controles Remotos -> Controle Simples(liga, desliga) e Avançado(liga, desliga, configurações(brilho lampada, volume da tv) )
 * 
 */

using SmartControlBridge.Entities;

IDevice tv = new Tv();
AdvancedRemoteControl tv_remoteControl = new(tv);
tv_remoteControl.Ligar();
tv_remoteControl.Desligar();
tv_remoteControl.AumentarVolume();
tv_remoteControl.DiminuirVolume();

Console.WriteLine();
IDevice lamp = new Lamp();
RemoteControl lamp_remoteControl = new SimpleRemoteControl(lamp);
lamp_remoteControl.Ligar();
lamp_remoteControl.Desligar();

Console.WriteLine();
AdvancedRemoteControl lamp_advancedRemoteControl = new(lamp);
lamp_advancedRemoteControl.AumentarVolume();
lamp_advancedRemoteControl.DiminuirVolume();