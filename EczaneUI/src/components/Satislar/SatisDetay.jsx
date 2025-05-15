import { useEffect, useState } from "react";
import "./SatisDetay.css";
import GetSatisDetay from "../../api/GetSatisDetay";
import { Button, Card, Row } from "antd";

const SatisDetay = ({ satis, setIsOpen }) => {
  const [satisDetay, setSatisDetay] = useState(null);

  useEffect(() => {
    const fetchSatisDetay = async () => {
      const resultSatisDetay = await GetSatisDetay(satis.id);
      setSatisDetay(resultSatisDetay);
    };
    fetchSatisDetay();
  }, [satis.id]);

  return (
    <Card style={{display:"grid"}}>
      <div style={{display:"flex", justifyContent:"right", alignItems:"center", paddingBottom:"10px"}}>
        <Button type="primary" danger onClick={() => setIsOpen(false)}>
        Kapat
      </Button>
      </div>
      {satisDetay &&
        satisDetay.satisDetaylar.map((ilacDto) => (
          <div>
          <Card key={ilacDto.ilac.id}>
            <div>İlaç Adı: {ilacDto.ilac.adi}</div>
            <div>Miktarı: {ilacDto.miktar} | Fiyatı: {ilacDto.ilac.fiyati}</div>
            <div>Satış Tutarı: {ilacDto.ilac.fiyati * ilacDto.miktar} </div>
          </Card>
          </div>
        ))}
      {satisDetay && (
        <div>Toplam Satış Tutarı: {satisDetay.toplamTutar}</div>
      )}
    </Card>
  );
};

export default SatisDetay;
