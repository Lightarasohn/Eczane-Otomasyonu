import { useState } from "react";
import "./Satislar.css";
import { Card, List, Modal } from "antd";
import SatisDetay from "./SatisDetay";

const Satislar = ({ satislar }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedSatis, setSelectedSatis] = useState(null);

  return (
    <>
      <List
        grid={{ gutter: 16, column: 4 }}
        dataSource={[...satislar].reverse()}
        pagination={{
          pageSize: 12,
          showSizeChanger: false,
          showLessItems: true,
        }}
        renderItem={(satis) => (
          <List.Item key={satis.id}>
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
          </List.Item>
        )}
      />

      <Modal
        open={isOpen}
        onCancel={() => setIsOpen(false)}
        footer={null}
        closable={false}
        destroyOnClose
      >
        {selectedSatis && <SatisDetay satis={selectedSatis} setIsOpen={setIsOpen} />}
      </Modal>
    </>
  );
};

export default Satislar;
