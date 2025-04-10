Feature: Bokning via gränssnitt

Scenario: Användaren gör en bokning
  Given att användaren öppnar bokningssidan
  When användaren fyller i bokningsformuläret
  And användaren klickar på boka
  Then ska användaren se en bekräftelse