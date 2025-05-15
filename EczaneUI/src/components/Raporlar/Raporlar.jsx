import { useState } from "react";
import { Card, Row, Col, Modal } from "antd";
import "./Raporlar.css";
import RaporDetay from "./RaporDetay";
import GetRaporDetay from "../../api/GetRaporDetay";

const Raporlar = ({ raporlar }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [raporDetay, setRaporDetay] = useState(null);

  const handleRaporClick = async (rapor) => {
    const detay = await GetRaporDetay(rapor.id);
    setRaporDetay(detay);
    setIsOpen(true);
  };

  return (
    <>
      <Row gutter={[16, 16]}>
        {[...raporlar].reverse().map((rapor) => (
          <Col span={8} key={rapor.id}>
            <Card hoverable onClick={() => handleRaporClick(rapor)}>
              <div>Rapor ID: {rapor.id}</div>
              <div>Başlangıç: {rapor.baslangicTarihi}</div>
              <div>Bitiş: {rapor.bitisTarihi}</div>
            </Card>
          </Col>
        ))}
      </Row>

      <Modal
  open={isOpen}
  onCancel={() => setIsOpen(false)}
  closable={false}
  footer={null}
  destroyOnClose
>
  {raporDetay && <RaporDetay raporDetay={raporDetay} setIsOpen={setIsOpen} />}
</Modal>

    </>
  );
};

export default Raporlar;
