import { useState } from "react";
import "./Satislar.css";
import { Card, Row, Col, Modal } from "antd";
import SatisDetay from "./SatisDetay";

const Satislar = ({ satislar }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedSatis, setSelectedSatis] = useState(null);

  return (
    <>
      <Row gutter={[16, 16]}>
        {[...satislar].reverse().map((satis) => (
          <Col span={6} key={satis.id}>
            <Card
              hoverable
              onClick={() => {
                setSelectedSatis(satis);
                setIsOpen(true);
              }}
            >
              <div className="card-text">Satış ID: {satis.id}</div>
              <div className="card-text">Email: {satis.aliciEmail}</div>
              <div className="card-text">
                Tarih: {satis.satisTarihi.replace("T", "  Saat:  ")}
              </div>
            </Card>
          </Col>
        ))}
      </Row>

      <Modal
        open={isOpen}
        onCancel={() => setIsOpen(false)}
        footer={null}
        destroyOnClose
      >
        {selectedSatis && <SatisDetay satis={selectedSatis} setIsOpen={setIsOpen} />}
      </Modal>
    </>
  );
};

export default Satislar;
