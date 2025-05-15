const RaporOluştur = async (startDate, endDate, satislar) => {
  const filteredSatislar = satislar.filter(x => {
    const satisDate = new Date(x.satisTarihi);
    return satisDate >= new Date(startDate) && satisDate <= new Date(endDate);
});

  let returnedResultRapor = null;

  const raporRequestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      BaslangicTarihi: startDate,
      BitisTarihi: endDate,
    }),
  };

  try {
    const response = await fetch(
      "http://localhost:5169/api/rapor",
      raporRequestOptions
    );
    if (response.ok) {
      returnedResultRapor = await response.json();
      console.log(`Rapor ${returnedResultRapor.id} oluşturuldu`);
      for (const satis of filteredSatislar) {
        const raporSatisRequestOptions = {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            RaporId: returnedResultRapor.id,
            SatisId: satis.id,
          }),
        };

        try {
          const responseRaporSatis = await fetch(
            "http://localhost:5169/api/rapor-satis",
            raporSatisRequestOptions
          );
          if (responseRaporSatis.ok) {
            console.log(
              `${returnedResultRapor.id} Numaralı Rapora Satis ${satis.id} eklendi`
            );
          }
        } catch {
          console.log(`Satis ${satis.id} Rapora eklenemedi`);
        }
      }
    }
  } catch {
    console.log("Rapor oluşturulamadi");
  }

  return returnedResultRapor;
};

export default RaporOluştur;
