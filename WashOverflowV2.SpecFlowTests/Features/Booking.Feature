Feature: Boka biltvätt

  Scenario: Kund bokar en tid
    Given att en kund är inloggad
    And kunden befinner sig på bokningssidan
    When kunden väljer station "Västra Hamnen"
    And väljer paket "Deluxe"
    And anger datum "2025-04-15"
    Then ska bokningen sparas
    And kunden ser en bekräftelse