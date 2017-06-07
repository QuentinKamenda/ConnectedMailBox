import Constellation
import subprocess
import time

@Constellation.MessageCallback()
def TakePhoto():
    Constellation.WriteInfo('Photo prise')
    subprocess.call("/home/pi/Documents/FileCamera/allume.sh",shell=True)
    time.sleep(1)
    subprocess.call("/home/pi/Documents/FileCamera/camera.sh",shell=True)
    time.sleep(1)
    subprocess.call("/home/pi/Documents/FileCamera/eteind.sh",shell=True)


@Constellation.MessageCallback()
def Allume():
    Constellation.WriteInfo('LED Allumée')
    subprocess.call("/home/pi/Documents/FileCamera/allume.sh",shell=True)

@Constellation.MessageCallback()
def Eteind():
    Constellation.WriteInfo('LED Eteinte')
    subprocess.call("/home/pi/Documents/FileCamera/eteind.sh",shell=True)


def OnExit():
    pass

def OnStart():

    print("Hellow !")

    Constellation.WriteInfo("Hi I'm '%s' and I run on %s. IsConnected = %s | IsStandAlone = %s " % (Constellation.PackageName, Constellation.SentinelName, Constellation.IsConnected, Constellation.IsStandAlone))

    Constellation.WriteInfo("Testing in process...")


# Start without break ! You need to implement a "While true" even if your script stop !
# Constellation.StartAsync()
# while Constellation.IsRunning:
#     pass
#     time.sleep(1) 

# Start with embedded loop (the code after this method will newer call)
# Constellation.Start(); 

# Start by calling your custom method then embedded loop to keep your script running
Constellation.Start(OnStart);