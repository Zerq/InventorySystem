# InventorySystem
A simple system using a standard barcode scanner and dymo labelmanager to keep a database of for tracking object and containers.
The idea is to only track where an item was last so there is no item removal action other then total remove from the system.

https://www.amazon.com/DYMO-LabelManager-Label-Maker-1768960/dp/B00464E5P2
http://www.aliexpress.com/item/USB-Negative-film-scanner-portable-barcode-scanner-scaner-barcode-reader-Bar-Code-scanner-leitor-de-codigo/32452127851.html?spm=2114.13010608.0.96.dNMKfI

Additionally i am working on a Phone app mostly for adding things to boxes without having to use the pc... (the PC app will run in tray and function as a server communicating with the phone app..)
I also plan on allowing for printing of labels with regular printer and to make the phone app function as a substitute for the barcode scanner later on.

I am using a truncated Guid right now for the PC app since i want to limit label size to save money  (label tape does cost a bunch even if most product already come with a label) I do this by checking the database for duplicate of the limited guid and repeating if it fails.
(If one later uses method of printing Barcode or QR code on a regular printer and using the phone to scan then this will also function quite well as the database itself is not as picky about Id size)