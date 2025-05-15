import { Card, Button, Row } from "antd";
import "./RaporDetay.css";

const RaporDetay = ({ raporDetay, setIsOpen }) => {
  if (!raporDetay || !raporDetay.rapor) {
    return <div>Yükleniyor...</div>;
  }

  const { raporDetaylar, toplamRaporTutari, rapor } = raporDetay;

  return (
    <div>
        <Row style={{justifyContent:"space-between", alignItems:"center"}}>
            <h3>Rapor ID: {rapor.id}</h3>
            <Button type="primary" danger variant="solid" onClick={() => setIsOpen(false)}>Kapat</Button>
        </Row>
      <p>Tarih Aralığı: {rapor.baslangicTarihi} - {rapor.bitisTarihi}</p>
      <p>Toplam Tutar: {toplamRaporTutari}</p>

      {raporDetaylar.map((detay) => (
        <Card key={detay.satisId} style={{ marginTop: "16px" }}>
          <div>Satış ID: {detay.satis.id}</div>
          <div>Alici Email: {detay.satis.aliciEmail}</div>
          <div>Tarih: {detay.satis.satisTarihi.replace("T", "  Saat:  ")}</div>
          <hr />
          {detay.satisDetay.satisDetaylar.map((ilacDto) => (
            <div key={ilacDto.ilacId}>
              <p>İlaç: {ilacDto.ilac.adi}</p>
              <p>Miktar: {ilacDto.miktar}</p>
              <p>Fiyat: {ilacDto.ilac.fiyati}</p>
              <p>Toplam: {ilacDto.ilac.fiyati * ilacDto.miktar}</p>
              <hr />
            </div>
          ))}
        </Card>
      ))}
    </div>
  );
};

export default RaporDetay;