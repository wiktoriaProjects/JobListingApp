

window.initializeMap = (mapId, location) => {
    const map = L.map(mapId).setView([51.505, -0.09], 13); 

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    if (location) {
        // Geocode location (using a simple example here, you might want to use a geocoding service)
        fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${location}`)
            .then(response => response.json())
            .then(data => {
                if (data.length > 0) {
                    const lat = data[0].lat;
                    const lon = data[0].lon;
                    const latLon = [lat, lon];
                    map.setView(latLon, 13);
                    L.marker(latLon).addTo(map)
                        .bindPopup(location)
                        .openPopup();
                }
            });
    }
};
