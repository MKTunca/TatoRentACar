function hesapla(h_id) {
    var gun = document.getElementById('gun');
    var fiyat = document.getElementById('fiyat_' + h_id);
    var sonuc = document.getElementById('sonuc');
    sonuc.value = parseInt(gun.value) * parseInt(fiyat.value);
}